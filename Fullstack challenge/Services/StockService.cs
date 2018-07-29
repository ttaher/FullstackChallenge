using System;
using System.Collections.Generic;
using System.Linq;
using Fullstack.Challenge.Data;
using Fullstack.Challenge.Models;

namespace Fullstack.Challenge.Services
{
	public class StocksService
	{
		private readonly ItemRepository _itemRepository;

		public StocksService(ItemRepository itemRepository)
		{
			_itemRepository = itemRepository ?? throw new ArgumentNullException(nameof(itemRepository));
		}

		public List<Stock> GetStocksAvailable()
		{
			return _itemRepository.GetAlItems().Where(x => x.Quantity > 0)
				.Select(it => new Stock
				{
					ItemName = it.Name,
					Quantity = it.Quantity,
					Price = it.Price,
					Id = it.Id,
					img = it.img,
					min = it.min
				}).ToList();
		}
		public List<Stock> GetStocks()
		{
			return _itemRepository.GetAlItems()
				.Select(it => new Stock
				{
					ItemName = it.Name,
					Quantity = it.Quantity,
					Price = it.Price,
					Id = it.Id,
					img = it.img,
					min = it.min
				}).ToList();
		}

		public int GetTotalDeducts(string ids)
		{
			return _itemRepository.GetAlItems().Where(x => ids.Contains(x.Id.ToString())).Sum(x => x.Price);
		}
		public bool UpdateList(List<Item> _items)
		{
			return _itemRepository.UpdateItems(_items);
		}
		public bool UpdateList(Item _item)
		{
			return _itemRepository.UpdateItems(_item);
		}
	}
}