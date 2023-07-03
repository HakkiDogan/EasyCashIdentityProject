using EasyCashIdentityProject.BusinessLayer.Abstract;
using EasyCashIdentityProject.DataAccessLayer.Abstract;
using EasyCashIdentityProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashIdentityProject.BusinessLayer.Concrete
{
    public class CustomerAccountProcessManager : ICustomerAccountProcessService
    {
        private readonly ICustomerAccountProcessDal _customerAccountProcessDal;

        public CustomerAccountProcessManager(ICustomerAccountProcessDal customerAccountProcessDal)
        {
            _customerAccountProcessDal = customerAccountProcessDal;
        }

        public void Delete(CustomerAccountProcess entity)
        {
            _customerAccountProcessDal.Delete(entity);
        }

        public CustomerAccountProcess GetById(int id)
        {
            return _customerAccountProcessDal.GetById(id);
        }

        public List<CustomerAccountProcess> GetList()
        {
            return _customerAccountProcessDal.GetList();
        }

        public void Insert(CustomerAccountProcess entity)
        {
            _customerAccountProcessDal.Insert(entity);
        }

        public void Update(CustomerAccountProcess entity)
        {
            _customerAccountProcessDal.Update(entity);
        }
    }
}
