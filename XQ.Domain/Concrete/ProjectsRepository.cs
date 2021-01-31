using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XQ.Domain.Abstract;
using XQ.Domain.Entities;

namespace XQ.Domain.Concrete
{
    /// <summary>
    /// 项目数据仓库的接口实现
    /// </summary>
    public class ProjectsRepository : IProjectsRepository
    {
        private EFDbcontext projectsContext = new EFDbcontext();

        /// <summary>
        /// 获取全部项目信息
        /// </summary>
        public IEnumerable<Projects> Projects
        {
            get
            {
                return projectsContext.Projects;
            }
        }

        /// <summary>
        /// 添加项目信息
        /// </summary>
        /// <param name="projectModel"></param>
        /// <returns></returns>
        public bool Add(Projects projectModel)
        {
            try
            {
                if(projectModel!=null)
                {
                    projectsContext.Projects.Add(projectModel);
                    projectsContext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 删除项目信息
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        public bool Delete(int projectId)
        {
            try
            {
                Projects projectModel = projectsContext.Projects.FirstOrDefault(x => x.ProjectId == projectId);
                if(projectModel!=null)
                {
                    projectsContext.Projects.Remove(projectModel);
                    projectsContext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 修改项目信息
        /// </summary>
        /// <param name="projectModel"></param>
        /// <returns></returns>
        public bool Update(Projects projectModel)
        {
            try
            {
                if(projectModel!=null)
                {
                    Projects oldModel = projectsContext.Projects.FirstOrDefault(x => x.ProjectId == projectModel.ProjectId);
                    oldModel.ProjectCode = projectModel.ProjectCode;
                    oldModel.ProjectDesc = projectModel.ProjectDesc;
                    projectsContext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 获取指定项目信息
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        public Projects ProjectInfo(int projectId)
        {
            projectsContext.Configuration.ProxyCreationEnabled = true;
            projectsContext.Configuration.LazyLoadingEnabled = true;

            Projects projectInfo = projectsContext.Projects.FirstOrDefault(x => x.ProjectId.Equals(projectId));
            return projectInfo;

        }
    }
}
