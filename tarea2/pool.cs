using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class Program
{		
	private static Random _random = new();
	private static List<string> _busyDealers = new();
	
	public static async Task Main()
	{
		for (int i = 0; i < 5; i++) 
		{
			var dealer = DealersPool.Instance.AssignDealer();
			
			if (string.IsNullOrEmpty(dealer))
				Console.WriteLine("No hay repartidores en este momento.");
			else
			{
				_busyDealers.Add(dealer);
				Console.WriteLine($"Se asignó a {dealer} para la entrega.");
			}
		}
		
		for (int i = 0; i < _busyDealers.Count; i++) 
		{
			await Task.Delay(_random.Next(500, 1000));
			DealersPool.Instance.CompleteDelivery(_busyDealers[i]);
			Console.WriteLine($"{_busyDealers[i]} ha completado la entrega.");
			
		}
	}
	
	public class DealersPool
	{
		private static DealersPool _instance = new();
		
		private Random _random = new();
		private List<string> _availableDealers = new() 
		{
			"Juan", "Pedro", "Pepe"
		};

		public static DealersPool Instance => _instance;
		
		public string AssignDealer()
		{
			if (_availableDealers.Count == 0)
				return string.Empty;
			
			var dealer = _availableDealers[_random.Next(0, _availableDealers.Count)];
			_availableDealers.Remove(dealer);
			return dealer;
		}
		public void CompleteDelivery(string dealer) => _availableDealers.Add(dealer);
	}
}