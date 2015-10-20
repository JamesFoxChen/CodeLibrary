using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CL.Biz.Common;
using CL.CrossDomain.DomainModel.Background.Other.Request;
using CL.CrossDomain.DomainModel.Background.Other.Response;
using CL.DAL.DataAccess;
using CL.DAL.DataModel.Entities;
using CL.Framework.Utils;
using CL.Plugin.Qiniu;

namespace CL.Biz.Background.Other
{
    public class MPollImagesBiz
    {
        /// <summary>
        /// 获取移动端展示轮询列表
        /// </summary>
        /// <returns></returns>
        public List<MPollImagesResponse> GetMPollImageList()
        {
            try
            {
                var db = new CLDbContext();
                var result = from wai in db.MPollImages
                             select new MPollImagesResponse
                             {
                                 ID = wai.ID,
                                 ImageLink = wai.ImageLink,
                                 ImageID = wai.ImageID,
                                 Remark = wai.Remark,
                                 Created = wai.Created,
                                 Updated = wai.Updated,
                                 OrderIndex = wai.OrderIndex,
                                 BizID = wai.BizID
                             };

                var response = result.OrderBy(p => p.BizID).ThenBy(p => p.OrderIndex).ToList();
                foreach (var item in response)
                {
                    item.BizIDDesc = CodeValueUtil.GetMPollImageTypeDesc(item.BizID);
                    item.ImageUrl = QiniuImageMng.GetImage(item.ImageID, 100, 80);
                }

                return response;
            }
            catch (Exception ex)
            {
                TextLogUtil.ErrorWithException("获取移动端展示轮询列表(GetMPollImageList)", ex);
                return null;
            }
        }

        /// <summary>
        /// 获取移动端展示轮询信息
        /// </summary>
        /// <returns></returns>
        public MPollImagesResponse GetMPollImage(string id)
        {
            try
            {
                var db = new CLDbContext();
                var result = from wai in db.MPollImages
                             where wai.ID == id
                             select wai;

                return Mapper.DynamicMap<MPollImages, MPollImagesResponse>(result.FirstOrDefault());
            }
            catch (Exception ex)
            {
                TextLogUtil.ErrorWithException("获取移动端展示轮询信息(GetMPollImage)", ex);
                return null;
            }
        }

        /// <summary>
        /// 新增移动端展示轮询信息
        /// </summary>
        /// <returns></returns>
        public int AddMPollImage(MPollImagesRequest request)
        {
            try
            {
                var data = Mapper.DynamicMap<MPollImagesRequest, MPollImages>(request);
                var db = new CLDbContext();
                db.MPollImages.Add(data);

                int i = db.SaveChanges();
                return i;
            }
            catch (Exception ex)
            {
                TextLogUtil.ErrorWithException("新增移动端展示轮询信息(AddMPollImage)", ex);
                return -1;
            }
        }

        /// <summary>
        /// 修改移动端展示轮询信息
        /// </summary>
        /// <returns></returns>
        public int UpdateMPollImage(MPollImagesRequest request)
        {
            try
            {
                var db = new CLDbContext();
                var data = db.MPollImages.FirstOrDefault(p => p.ID == request.ID);
                data.ImageID = request.ImageID;
                data.ImageLink = request.ImageLink;
                data.Remark = request.Remark;
                data.OrderIndex = request.OrderIndex;
                data.Updated = DateTime.Now;
                int i = db.SaveChanges();

                return i;
            }
            catch (Exception ex)
            {
                TextLogUtil.ErrorWithException("修改移动端展示轮询信息(UpdateMPollImage)", ex);
                return -1;
            }
        }

        /// <summary>
        /// 删除微信活动图信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteMPollImage(string id, string adminID, string adminName)
        {
            try
            {
                var db = new CLDbContext();
                var data = db.MPollImages.FirstOrDefault(p => p.ID == id);
                db.MPollImages.Remove(data);
                int i = db.SaveChanges();
                return i;
            }
            catch (Exception ex)
            {
                TextLogUtil.ErrorWithException("删除微信活动图信息(DeleteMPollImage)", ex);
                return -1;
            }
        }
    }
}
