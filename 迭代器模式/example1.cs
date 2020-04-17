using System;
using System.Collections.Generic;
using System.Text;

namespace designmodedemo.迭代器模式
{
  public interface IIterator
  {
    void Previous();
    void Next();
    bool IsFirst();
    bool IsLast();
    object GetNextItem();
    object GetPreviousItem();
  }

  public class ProductIterator : IIterator
  {
    private List<object> _productList;
    private int _leftCursor;
    private int _rightCursor;

    public ProductIterator(ProductList productList)
    {
      _productList = productList.GetItems();
      _leftCursor = 0;
      _rightCursor =_productList.Count - 1;
    }

    public object GetNextItem()
    {
      return _productList[_leftCursor];
    }

    public object GetPreviousItem()
    {
      return _productList[_rightCursor];
    }

    public bool IsFirst()
    {
      return _rightCursor == -1;
    }

    public bool IsLast()
    {
      return _leftCursor == _productList.Count;
    }

    public void Next()
    {
      if (_leftCursor < _productList.Count)
      {
        _leftCursor++;
      }
    }

    public void Previous()
    {
      if (_rightCursor > -1)
      {
        _rightCursor--;
      }
    }
  }

  public abstract class CollectionBase
  {
    protected List<object> _items = new List<object>();

    public CollectionBase(List<object> items)
    {
      _items = items;
    }

    public void AddItem(object item)
    {
      _items.Add(item);
    }

    public void RemoveItem(object item)
    {
      _items.Remove(item);
    }

    public List<object> GetItems()
    {
      return _items;
    }

    public abstract IIterator CreateIterator();
  }

  public class ProductList : CollectionBase
  {
    public ProductList(List<object> products)
      : base(products)
    {

    }

    public override IIterator CreateIterator()
    {
      return new ProductIterator(this);
    }
  }
}
