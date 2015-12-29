using System.Collections;
using System.Collections.Generic;
using System;

public class RandomCollection<T> : ICollection<T>
{
	public int Count { get; private set; }

	public bool IsReadOnly { get; private set; }

	private List<T> _list;

	private Random _random;

	public RandomCollection()
	{
		_list = new List<T>();
		_random = new Random();
	}

	public void Add(T item)
	{
		_list.Add(item);
	}

	public bool Remove(T item)
	{
		return _list.Remove(item);
	}

	public void Clear()
	{
		_list.Clear();
	}

	public T GetRandomItem()
	{
		int randomIndex = _random.Next(_list.Count);
		return _list[randomIndex];
	}

	public bool Contains(T item)
	{
		return _list.Contains(item);
	}

	public void CopyTo(T[] list, int index)
	{
		_list.CopyTo(list, index);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return _list.GetEnumerator();
	}

	public IEnumerator<T> GetEnumerator()
	{
		return _list.GetEnumerator();
	}
}
