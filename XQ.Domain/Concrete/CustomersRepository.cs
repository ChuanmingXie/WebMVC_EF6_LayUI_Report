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
    /// 客户/机台数据仓库的接口实现
    /// </summary>
    public class CustomersRepository : ICustomersRepository
    {
        private EFDbcontext customersContext = new EFDbcontext();

        /// <summary>
        /// 获取全部的客户/机台数据
        /// </summary>
        public IEnumerable<Customers> Customers
        {
            get
            {
                return customersContext.Customers;
            }
        }

        /// <summary>
        /// 添加客户/机台数据
        /// </summary>
        /// <param name="customerModel"></param>
        /// <returns></returns>
        public bool Add(Customers customerModel)
        {
            try
            {
                if(null!=customerModel)
                {
                    customersContext.Customers.Add(customerModel);
                    customersContext.SaveChanges();
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
        /// 获取指定客户/机台信息
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public List<Customers> CustomerInfo(int customerId)
        {
            customersContext.Configuration.ProxyCreationEnabled = true;
            customersContext.Configuration.LazyLoadingEnabled = true;

            List<Customers> customerInfo = new List<Customers>();
            customerInfo = customersContext.Customers.Where(x => x.CustomerId.Equals(customerId)).ToList();
            return customerInfo;
        }

        /// <summary>
        /// 删除客户/机台信息
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public bool Delete(int customerId)
        {
            try
            {
                Customers customerModel = customersContext.Customers.FirstOrDefault(x => x.CustomerId == customerId);
                if(null!=customerModel)
                {
                    customersContext.Customers.Remove(customerModel);
                    customersContext.SaveChanges();
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

        public bool Update(Customers customerModel)
        {
            try
            {
                if(customerModel!=null)
                {
                    Customers oldModel = customersContext.Customers.FirstOrDefault(x => x.CustomerId == customerModel.CustomerId);
                    oldModel.CustomerName = customerModel.CustomerCode;
                    oldModel.CustomerCode = customerModel.CustomerCode;
                    customersContext.SaveChanges();
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
    }
}
