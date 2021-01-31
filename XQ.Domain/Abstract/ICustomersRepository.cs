using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XQ.Domain.Entities;

namespace XQ.Domain.Abstract
{
    /// <summary>
    /// 客户/机台数据仓库接口定义
    /// </summary>
    public interface ICustomersRepository
    {
        /// <summary>
        /// 添加客户/机台
        /// </summary>
        /// <param name="customerModel"></param>
        /// <returns></returns>
        bool Add(Customers customerModel);

        /// <summary>
        /// 跟新客户/机台
        /// </summary>
        /// <param name="customerModel"></param>
        /// <returns></returns>
        bool Update(Customers customerModel);

        /// <summary>
        /// 删除客户机台
        /// </summary>
        /// <param name="customerId">指定删除的Id</param>
        /// <returns></returns>
        bool Delete(int customerId);

        /// <summary>
        /// 获取全部客户/机台
        /// </summary>
        IEnumerable<Customers> Customers { get; }

        /// <summary>
        /// 获取指定客户机台的信息
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        List<Customers> CustomerInfo(int customerId);
    }
}
