using System.Collections.Generic;
using Fullstack.Challenge.Models;

namespace Fullstack.Challenge.Data
{
	public class ItemRepository
	{
		private static readonly List<Item> _items;

		public List<Item> GetAlItems()
		{
			return _items;
		}
		public bool UpdateItems(Item _item)
		{
			try
			{
				_items.Find(x => x.Id == _item.Id).Quantity -= _item.Quantity;
				return true;
			}
			catch (System.Exception)
			{
				return false;

			}
		}
		public bool UpdateItems(List<Item> _items)
		{
			try
			{
				foreach (var item in _items)
				{
					UpdateItems(item);
				}
				return true;
			}
			catch (System.Exception)
			{
				return false;
			}
		}

		static ItemRepository()
		{
			_items = new List<Item>
			{
				new Item
				{
					Id = 1,
					Name = "Bronze sword: low quality, low price",
					Price = 8,
					Quantity = 10,
					img="bronze_sword.png",
					min =0
				},
				new Item
				{
					Id = 2,
					Name = "Wooden shield",
					Price = 15,
					Quantity = 5,
					img="wooden_shield.png",
					min =0
				},
				new Item
				{
					Id = 3,
					Name = "Battle axe",
					Price = 12,
					Quantity = 2,
					img="battle_axe.png",
					min =0
				},
				new Item
				{
					Id = 4,
					Name = "Longsword, carefully crafted to slay your enemies",
					Price = 31,
					Quantity = 1,
					img ="longsword.png",
					min =0
				},
			};
		}
	}
}