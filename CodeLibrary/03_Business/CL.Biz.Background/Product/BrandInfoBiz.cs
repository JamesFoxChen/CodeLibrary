using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CL.Biz.Common;
using CL.CrossDomain.DomainModel.Background.Product.Request;
using CL.CrossDomain.DomainModel.Background.Product.Response;
using CL.DAL.DataAccess;
using CL.DAL.DataModel.Entities;
using CL.Framework.Utils;
using CL.CrossDomain.DomainModel.Common;

namespace CL.Biz.Background.Product
{
    public class BrandInfoBiz
    {

        #region 获取品牌列表
        /// <summary>
        /// 获取品牌列表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public BrandListResponse GetBrandList(BrandListRequest query)
        {
            try
            {
                var db = new CLDbContext();
                var result = from p in db.BrandInfo select p;
                //查询类型名称
                if (!string.IsNullOrWhiteSpace(query.BrandName))
                {
                    result = result.Where(p => p.BrandName.Contains(query.BrandName));
                }
                if (query.ShowStatus != null)
                {
                    result = result.Where(p => p.ShowStatus == query.ShowStatus);
                }
                if (query.DataSource != null)
                {
                    result = result.Where(p => p.DataSource == query.DataSource);
                }
                var response = new BrandListResponse();
                response.TotalCount = result.Count();
                var lstResult = result
                                .OrderBy(p => p.OrderIndex)
                                .Take(query.PageSize * query.PageIndex)
                                .Skip(query.PageSize * (query.PageIndex - 1))
                                .ToList();
                response.DataList = Mapper.DynamicMap<List<BrandInfo>, List<BrandListInfoResponse>>(lstResult);
                foreach (var item in response.DataList)
                {
                    item.DataSourceDesc = CodeValueUtil.GetDataSourceTypeDesc(item.DataSource);
                    item.ShowStatusDesc = CodeValueUtil.GetShowStatusDesc(item.ShowStatus.ToInt32OrNull());
                }
                return response;

            }
            catch (Exception ex)
            {
                TextLogUtil.ErrorWithException("获取品牌(GetBrandList)", ex);
                return null;
            }
        }
        #endregion

        #region 获取品牌信息
        /// <summary>
        /// 获取品牌信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BrandInfoRequest GetBrandInfo(string id)
        {
            try
            {
                var db = new CLDbContext();
                var result = db.BrandInfo.FirstOrDefault(p => p.ID == id);
                return Mapper.DynamicMap<BrandInfo, BrandInfoRequest>(result);
            }
            catch (Exception ex)
            {
                TextLogUtil.ErrorWithException("根据id获取品牌(GetBrandInfo)", ex);
                return null;
            }
        }
        #endregion

        #region 品牌信息新增
        public ResponseInfo AddBrandInfo(BrandInfoRequest request)
        {
            try
            {
                request.ID = StringUtil.GetGUID();
                var brandInfo = Mapper.DynamicMap<BrandInfoRequest, BrandInfo>(request);

                var db = new CLDbContext();
                db.BrandInfo.Add(brandInfo);
                db.SaveChanges();
                return new ResponseInfo { IsSuccess = true };
            }
            catch (Exception ex)
            {
                TextLogUtil.ErrorWithException("新增品牌信息(AddBrandInfo)", ex);
                return new ResponseInfo
                {
                    IsSuccess = false,
                    Msg = ex.Message
                };
            }
        }
        #endregion

        #region 品牌信息修改
        public ResponseInfo UpdateBrandInfo(BrandInfoRequest request)
        {
            try
            {
                var db = new CLDbContext();
                var data = db.BrandInfo.FirstOrDefault(p => p.ID == request.ID);
                data.BrandName = request.BrandName;
                data.LogoImage = request.LogoImage;
                data.ShowStatus = request.ShowStatus;
                data.Phone = request.Phone;
                data.Introduce = request.Introduce;
                data.Company = request.Company;
                data.Updated = DateTime.Now;

                db.SaveChanges();
                return new ResponseInfo { IsSuccess = true };
            }
            catch (Exception ex)
            {
                TextLogUtil.ErrorWithException("更新品牌信息(UpdateBrandInfo)", ex);
                return new ResponseInfo
                {
                    IsSuccess = false,
                    Msg = ex.Message
                };
            }
        }
        #endregion

        #region 品牌信息删除
        public ResponseInfo DeleteBrandInfo(string Id)
        {
            try
            {
                var db = new CLDbContext();
                var data = db.BrandInfo.FirstOrDefault(p => p.ID == Id);
                db.BrandInfo.Remove(data);

                db.SaveChanges();
                return new ResponseInfo { IsSuccess = true };
            }
            catch (Exception ex)
            {
                TextLogUtil.ErrorWithException("品牌信息删除(DeleteBrandInfo)", ex);
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
