﻿using Microsoft.EntityFrameworkCore;
using Restaurant_API.Data;
using Restaurant_API.Models;
using Restaurant_API.Repository.IRepository;

namespace Restaurant_API.Repository
{
	public class TableRepository : ITableRepository
	{
		RestaurantContext _context;
        public TableRepository(RestaurantContext context)
        {
            _context = context;
        }

		//public async Task<IEnumerable<Table>> CheckAvailabiltyAndReturnAvailableTables(DateTime timeFrom, int partySize)
		//{
		//	return await _context.Tables
		//		.Where(t=> t.Seats >= partySize)
		//		.Where(t => !t.Reservations.Any(r => r.DateTimeFrom < timeFrom && r.DateTimeTo > timeFrom.AddHours(2)))
		//		.ToListAsync();
		//}

		//Ienum eller List? Man gör redan tolist, blir det mer effektivt?
		public async Task<IEnumerable<Table>> GetAllTables()
		{
			return await _context.Tables.Include(t=> t.Reservations).ToListAsync();
		}

		public async Task CreateTable(Table table)
		{
			await _context.Tables.AddAsync(table);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteTable(Table table)
		{
			if (table != null)
			{
				_context.Tables.Remove(table);
				await _context.SaveChangesAsync();
			}
		}

		public async Task UpdateTable(Table table)
		{
			_context.Tables.Update(table);
			await _context.SaveChangesAsync();
		}

		public async Task<Table> GetTableById(int id)
		{
			return await _context.Tables.FindAsync(id);
		}
	}
}
