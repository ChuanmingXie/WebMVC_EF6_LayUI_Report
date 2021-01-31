using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using XQ.Domain.Abstract;
using XQ.Domain.Entities;
using XQ.WebUI.Infrastructure.Abstract;
using XQ.WebUI.Models;

namespace XQ.WebUI.Controllers
{
    public class ProjectController : Controller
    {
        private IProjectsRepository IProject;
		private IEntityRepository IEntityProject;
		/// <summary>
		/// 初始化成员函数
		/// </summary>
		/// <param name="iProject"></param>
		public ProjectController(IProjectsRepository iProject, IEntityRepository iEntityProject)
		{
			IProject = iProject;
			IEntityProject = iEntityProject;
		}

		// GET: Project
		public ActionResult ProjectIndex()
        {
            return View();
        }

		/// <summary>
		/// 获取项目信息
		/// </summary>
		/// <param name="page"></param>
		/// <param name="limit"></param>
		/// <returns></returns>
		public JsonResult GetProjectInfo(int page,int limit)
		{
			List<ProjectModel> projectModels = IEntityProject.GetProjectModels();
			return Json(new
			{
				code = 0,
				msg = "",
				count = projectModels.Count(),
				data = projectModels.Skip((page - 1) * limit).Take(limit).ToList(),
				page=page,
				limit=limit,
			}, JsonRequestBehavior.AllowGet);
		}

        /// <summary>
        /// 添加新的项目
        /// </summary>
        /// <param name="project">前台提交的Projects实体</param>
        /// <returns></returns>
        [HttpPost]
        public bool AddProject(Projects addProject)
        {
			return IProject.Add(addProject);
        }

        /// <summary>
        /// 更新所选项目
        /// </summary>
        /// <param name="updateProject">前台提交的Projects实体</param>
        /// <returns></returns>
        [HttpPost]
        public bool UpdateProject(Projects updateProject)
        {
			return IProject.Update(updateProject);         
        }

        /// <summary>
        /// 添加项目、编辑项目、添加任务的弹出层视图
        /// 将会在界面上进行初始化
        /// 编辑项目:ProjectCode、ProjectDesc
        /// 添加任务:
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ProjectView()
        {
            string projectId = Request.QueryString.ToString().Substring(Request.QueryString.ToString().LastIndexOf("=")+1);
            Projects project = IProject.ProjectInfo(Convert.ToInt32(projectId));
            return View(project);
        }

        /// <summary>
        /// 辅助方法,配合layui返回数据
        /// </summary>
        /// <param name="projectId">前台传入的ProjectId</param>
        /// <returns></returns>
        [HttpGet]
        public string ProjectTemp(int projectId)
        {
            return projectId.ToString();
        }
    }
}