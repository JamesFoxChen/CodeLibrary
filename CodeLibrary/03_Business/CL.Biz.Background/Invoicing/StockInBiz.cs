using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CL.Biz.Background.Product;
using CL.CrossDomain.DomainModel.Background.Invoicing.Request;
using CL.CrossDomain.DomainModel.Background.Invoicing.Response;
using CL.CrossDomain.DomainModel.Background.Product.Request;
using CL.CrossDomain.DomainModel.Common;
using CL.DAL.DataAccess;
using CL.DAL.DataModel.Entities;
using CL.Framework.Utils;

namespace CL.Biz.Background.Invoicing
{
    public class StockInBiz
    {

        #region 获取入库流水记录
        /// <summary>
        /// 获取入库流水记录
        /// </summary>
        /// <returns></returns>
        public StockInLogListResponse GetStockInLogList(StockInLogRequest request)
        {
            try
            {
                var db = new CLDbContext();
                var result = from si in db.StockInLog
                             join ai in db.AdminInfo on si.UserID equals ai.ID into ljAdminInfo
                             from ai in ljAdminInfo.DefaultIfEmpty()
                             join pi in db.ProductInfo on si.ProductID equals pi.ID into ljProductInfo
                             from pi in ljProductInfo.DefaultIfEmpty()
                             select new StockInLogListInfoResposne
                             {
                                 ID = si.ID,
                                 DisplayID = pi.DisplayID,
                                 ProductID = si.ProductID,
                                 ProductName = pi.ProductName,
                                 BarCode = pi.BarCode,
                                 SpecID = si.SpecID,
                                 StockInCount = si.StockInCount,
                                 UserID = ai.ID,
                                 UserName = ai.AdminName,
                                 Created = si.Created
                             };

                if (!string.IsNullOrWhiteSpace(request.DisplayID))
                {
                    result = result.Where(p => p.DisplayID == request.DisplayID);
                }
                if (!string.IsNullOrWhiteSpace(request.ProductID))
                {
                    result = result.Where(p => p.ProductID == request.ProductID);
                }
                if (!string.IsNullOrWhiteSpace(request.BarCode))
                {
                    result = result.Where(p => p.BarCode == request.BarCode);
                }
                if (request.StockInStart != null)
                {
                    result = result.Where(p => p.Created >= request.StockInStart);
                }
                if (request.StockInEnd != null)
                {
                    result = result.Where(p => p.Created <= request.StockInEnd);
                }
                var response = new StockInLogListResponse();
                response.TotalCount = result.Count();
                response.DataList = result
                                    .OrderByDescending(p => p.Created)
                                    .Skip((request.PageIndex - 1) * request.PageSize)
                                    .Take(request.PageSize)
                                    .ToList();
                return response;
            }
            catch (Exception ex)
            {
                TextLogUtil.ErrorWithException("获取入库流水记录(GetStockInLogList)", ex);
                return null;
            }
        }

        #endregion

        #region 入口操作
        /// <summary>
        /// 入口操作
        /// </summary>
        /// <returns></returns>
        public ResponseInfo StockIn(StockInRequest request)
        {
            try
            {
                request.ID = StringUtil.GetGUID();
                request.Created = DateTime.Now;
                request.SpecID = "11";
                var stockInfo = Mapper.DynamicMap<StockInRequest, StockInLog>(request);

                var db = new CLDbContext();
                var productInfo = db.ProductInfo.FirstOrDefault(p => p.ID == request.ProductID);
                productInfo.StorageCount += request.StockInCount;

                db.StockInLog.Add(stockInfo);
                db.SaveChanges();
                return new ResponseInfo { IsSuccess = true };
            }
            catch (Exception ex)
            {
                TextLogUtil.ErrorWithException("入口操作(StockIn)", ex);
                return new ResponseInfo
                {
                    IsSuccess = false,
                    Msg = ex.Message
                };
            }
        }

        #endregion
    }
}
