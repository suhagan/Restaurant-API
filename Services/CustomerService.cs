﻿using Restaurant_API.Models;
using Restaurant_API.Models.DTOs;
using Restaurant_API.Models.DTOs.CreateDTOs;
using Restaurant_API.Repository.IRepository;
using Restaurant_API.Services.IServices;

namespace Restaurant_API.Services
{
    public class CustomerService : ICustomerService
	{
		private readonly ICustomerRepository _customerRepo;
		public CustomerService(ICustomerRepository customerRepo)
		{
			_customerRepo = customerRepo;
		}


		public async Task<int> CreateCustomer(CreateCustomerDTO customerDTO)
		{
			if (customerDTO == null)
			{
				throw new ArgumentNullException(nameof(customerDTO));
			}

			int id = await _customerRepo.CreateCustomer(new Customer
			{
				Name = customerDTO.Name,
				Phone = customerDTO.PhoneNr
			});

			return id;
		}

		public async Task DeleteCustomer(int id)
		{
			await _customerRepo.DeleteCustomer(id);
		}

		public async Task<IEnumerable<CustomerDTO>> GetAllCustomers()
		{
			var customers = await _customerRepo.GetAllCustomers();
			return customers.Select(c => new CustomerDTO
			{
				Id = c.Id,
				Name = c.Name,
				PhoneNr = c.Phone,
				reservationDTOs = c.Reservations.Select(r => new GetReservationDTO
				{
					ReservationNumber = r.ReservationNumber,
					CustomerName = r.Customer.Name,
					PartySize = r.PartySize,
					phoneNr = r.Customer.Phone,
					TableNr = r.TableNumberFK,
					timeFrom = r.DateTimeFrom,
					timeTo = r.DateTimeTo,
				})
			});
		}

		public async Task<CustomerDTO> GetCustomerById(int id)
		{
			Customer customer = await _customerRepo.GetCustomerById(id);

			if(customer == null)
			{
				throw new Exception();
			}

			return new CustomerDTO
			{
				Name = customer.Name,
				PhoneNr = customer.Phone
			};
		}

		public async Task UpdateCustomer(int id, CustomerDTO customerDTO)
		{
			var customer = await _customerRepo.GetCustomerById(id);

			customer.Name = customerDTO.Name;
			customer.Phone = customerDTO.PhoneNr;
			try
			{
				await _customerRepo.UpdateCustomer(customer);
			}
			catch (Exception ex)
			{

			}
		}
	}
}
