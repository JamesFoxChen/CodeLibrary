using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CL.Biz.Common;
using CL.CrossDomain.DomainModel.Background.Product.Request;
using CL.CrossDomain.DomainModel.Background.Product.Response;
using CL.CrossDomain.DomainModel.Common;
using CL.DAL.DataAccess;
using CL.DAL.DataModel.Entities;
using CL.Framework.Utils;

namespace CL.Biz.Background.Product
{
    public class ProductInfoBiz
    {

        #region 获取产品列表
        /// <summary>
        /// 获取产品列表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public ProductListResponse GetProductList(ProductListRequest query)
        {
            try
            {
                var db = new CLDbContext();
                var result = from pi in db.ProductInfo
                             join bi in db.BrandInfo on pi.BrandID equals bi.ID into ljBrandInfo
                             from bi in ljBrandInfo.DefaultIfEmpty()
                             select new ProductListInfoResponse
                             {
                                 ProductName = pi.ProductName,
                                 DisplayID = pi.DisplayID,
                                 ShowStatus = pi.ShowStatus,
                                 DataSource = pi.DataSource,
                                 OrderIndex = pi.OrderIndex,
                                 Created = pi.Created,
                                 Updated = pi.Updated,
                                 ID = pi.ID,
                                 BrandName = bi.BrandName
                             };

                //查询类型名称
                if (!string.IsNullOrWhiteSpace(query.ProductName))
                {
                    result = result.Where(p => p.ProductName.Contains(query.ProductName));
                }
                if (query.ShowStatus != null)
                {
                    result = result.Where(p => p.ShowStatus == query.ShowStatus);
                }
                if (query.DataSource != null)
                {
                    result = result.Where(p => p.DataSource == query.DataSource);
                }
                if (query.CreatedStartDate != null)
                {
                    result = result.Where(p => p.Created >= query.CreatedStartDate);
                }
                if (query.CreatedEndDate != null)
                {
                    result = result.Where(p => p.Created <= query.CreatedEndDate);
                }
                var response = new ProductListResponse();
                response.TotalCount = result.Count();
                var lstResult = result
                                .OrderBy(p => p.OrderIndex)
                                .Take(query.PageSize * query.PageIndex)
                                .Skip(query.PageSize * (query.PageIndex - 1))
                                .ToList();
                response.DataList = lstResult;
                foreach (var item in response.DataList)
                {
                    item.DataSourceDesc = CodeValueUtil.GetDataSourceTypeDesc(item.DataSource);
                    item.ShowStatusDesc = CodeValueUtil.GetShowStatusDesc(item.ShowStatus.ToInt32OrNull());
                }
                return response;
            }
            catch (Exception ex)
            {
                TextLogUtil.ErrorWithException("获取产品(GetProductList)", ex);
                return null;
            }
        }
        #endregion

        #region 获取产品信息
        /// <summary>
        /// 获取产品信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ProductInfoRequest GetProductInfo(string id)
        {
            try
            {
                var db = new CLDbContext();
                var result = db.ProductInfo.FirstOrDefault(p => p.ID == id);
                return Mapper.DynamicMap<ProductInfo, ProductInfoRequest>(result);
            }
            catch (Exception ex)
            {
                TextLogUtil.ErrorWithException("根据id获取产品(GetProductInfo)", ex);
                return null;
            }
        }
        #endregion

        #region 产品信息新增
        public ResponseInfo AddProductInfo(ProductInfoRequest request)
        {
            try
            {
                request.ID = StringUtil.GetGUID();
                request.DisplayID = UtilityBiz.GenerateProductDisplayID();
                var ProductInfo = Mapper.DynamicMap<ProductInfoRequest, ProductInfo>(request);

                var db = new CLDbContext();
                db.ProductInfo.Add(ProductInfo);
                db.SaveChanges();
                return new ResponseInfo { IsSuccess = true };
            }
            catch (Exception ex)
            {
                TextLogUtil.ErrorWithException("新增产品信息(AddProductInfo)", ex);
                return new ResponseInfo
                {
                    IsSuccess = false,
                    Msg = ex.Message
                };
            }
        }
        #endregion

        #region 产品信息修改
        public ResponseInfo UpdateProductInfo(ProductInfoRequest request)
        {
            try
            {
                var db = new CLDbContext();
                var data = db.ProductInfo.FirstOrDefault(p => p.ID == request.ID);
                data.ProductName = request.ProductName;
                data.DefaultPhotoUrl = request.DefaultPhotoUrl;
                data.ShowStatus = request.ShowStatus;
                data.PhotoUrl = request.PhotoUrl;
                data.Updated = DateTime.Now;

                db.SaveChanges();
                return new ResponseInfo { IsSuccess = true };
            }
            catch (Exception ex)
            {
                TextLogUtil.ErrorWithException("更新产品信息(UpdateProductInfo)", ex);
                return new ResponseInfo
                {
                    IsSuccess = false,
                    Msg = ex.Message
                };
            }
        }
        #endregion

        #region 产品信息删除
        public ResponseInfo DeleteProductInfo(string Id)
        {
            try
            {
                var db = new CLDbContext();
                var data = db.ProductInfo.FirstOrDefault(p => p.ID == Id);
                db.ProductInfo.Remove(data);

                db.SaveChanges();
                return new ResponseInfo { IsSuccess = true };
            }
            catch (Exception ex)
            {
                TextLogUtil.ErrorWithException("产品信息删除(DeleteProductInfo)", ex);
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
