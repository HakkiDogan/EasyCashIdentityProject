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
    public class CustomerAccountManager : ICustomerAccountService
    {
        private readonly ICustomerAccountDal _customerAccountDal;

        public CustomerAccountManager(ICustomerAccountDal customerAccountDal)
        {
            _customerAccountDal = customerAccountDal;
        }

        public void TDelete(CustomerAccount entity)
        {
            _customerAccountDal.Delete(entity);
        }

        public CustomerAccount TGetById(int id)
        {
            return _customerAccountDal.GetById(id);
        }

        public List<CustomerAccount> TGetList()
        {
            return _customerAccountDal.GetList();
        }

        public void TInsert(CustomerAccount entity)
        {
            _customerAccountDal.Insert(entity);
        }

        public void TUpdate(CustomerAccount entity)
        {
            _customerAccountDal.Update(entity);
        }
    }
}
