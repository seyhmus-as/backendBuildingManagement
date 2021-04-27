using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
	public class CardManager : IApartmentService
	{
		ICustomerDal _customerDal;
		public CardManager(ICustomerDal customerDal)
		{
			_customerDal = customerDal;
		}	
		[SecuredOperation("admin")]
		public IResult Add(Customer customer)
		{
			_customerDal.Add(customer);
			return new SuccessResult(Messages.CustomerAdded);
		}
		public IResult Delete(int id)
		{
			_customerDal.Delete(_customerDal.Get(p => p.Id == id));
			return new SuccessResult(Messages.CustomerDeleted);
		}
		public IResult Update(Customer customer)
		{
			/*var updatedL = _customerDal.Get(p => p.Id == customer.Id);
 			_customerDal.Update(updatedL);*/
			_customerDal.Update(customer);
			return new SuccessResult(Messages.CustomerUpdate);
		}
		public IDataResult<List<Customer>> GetAll()
		{
			return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(), Messages.CustomersListed);
		}
		public IDataResult<Customer> GetById(int customerId)
		{
			return new SuccessDataResult<Customer>(_customerDal.Get(p => p.Id == customerId));
		}
		public IDataResult<List<CustomerDetailDto>> GetCustomerDetails()
		{
			return new SuccessDataResult<List<CustomerDetailDto>>(_customerDal.GetCustomerDetails());
		}
	}
}
