﻿using DesignPattern.BusinessLayer.Abstract;
using DesignPattern.DataAccessLayer.Abstract;
using DesignPattern.DataAccessLayer.UnitOfWork;
using DesignPattern.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.BusinessLayer.Concrete
{
    public class CustomerManger : ICustomerService
    {
        private readonly ICustomerDal _customerDal;
        private readonly IUnitOfWorkDal _unitOfWorkDal;

        public CustomerManger(ICustomerDal customerDal, IUnitOfWorkDal unitOfWorkDal)
        {
            _customerDal = customerDal;
            _unitOfWorkDal = unitOfWorkDal;
        }

        public void TDelete(Customer t)
        {
            _customerDal.Delete(t);
            _unitOfWorkDal.Save();
        }

        public Customer TGetById(int id)
        {
            return _customerDal.GetById(id);

        }

        public List<Customer> TGetList()
        {
            return _customerDal.GetList();
        }

        public void TInsert(Customer t)
        {
            _customerDal.Insert(t);
            _unitOfWorkDal.Save();
        }

        public void TMultiUpdate(List<Customer> t)
        {
            _customerDal.MultiUpdate(t);
            _unitOfWorkDal.Save();
        }

        public void TUpdate(Customer t)
        {
            _customerDal.Update(t);
            _unitOfWorkDal.Save();
        }
    }
}
