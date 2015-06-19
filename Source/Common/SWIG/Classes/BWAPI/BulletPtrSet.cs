//------------------------------------------------------------------------------
// <auto-generated />
//
// This file was automatically generated by SWIG (http://www.swig.org).
// Version 3.0.5
//
// Do not make changes to this file unless you know what you are doing--modify
// the SWIG interface file instead.
//------------------------------------------------------------------------------

namespace SWIG.BWAPI {

public partial class BulletPtrSet : global::System.IDisposable 
#if !SWIG_DOTNET_1
    , global::System.Collections.Generic.ICollection<Bullet>
#endif
 {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal BulletPtrSet(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(BulletPtrSet obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~BulletPtrSet() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          bwapiPINVOKE.delete_BulletPtrSet(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      global::System.GC.SuppressFinalize(this);
    }
  }


  
  public int Count {
    get {
      return (int)size();
    }
  }

  public bool IsReadOnly {
    get { 
      return false; 
    }
  }

#if !SWIG_DOTNET_1
 public global::System.Collections.Generic.ICollection<Bullet> Values {
    get {
      global::System.Collections.Generic.ICollection<Bullet> values = new global::System.Collections.Generic.List<Bullet>();
      global::System.IntPtr iter = create_iterator_begin();
      try {
		  for (int i = 0;i < size();i++){
			values.Add(get_next_key(iter));
		}
      } catch (global::System.ArgumentOutOfRangeException) {
      }
	  return values;
    }
  }
 
  public bool Contains(Bullet item) {
    if ( ContainsKey(item)) {
      return true;
    } else {
      return false;
    }
  }

  public void CopyTo(Bullet[] array) {
    CopyTo(array, 0);
  }

  public void CopyTo( Bullet[] array, int arrayIndex) {
    if (array == null)
      throw new global::System.ArgumentNullException("array");
    if (arrayIndex < 0)
      throw new global::System.ArgumentOutOfRangeException("arrayIndex", "Value is less than zero");
    if (array.Rank > 1)
      throw new global::System.ArgumentException("Multi dimensional array.", "array");
    if (arrayIndex+this.Count > array.Length)
      throw new global::System.ArgumentException("Number of elements to copy is too large.");

   global::System.Collections.Generic.IList<Bullet> keyList = new global::System.Collections.Generic.List<Bullet>(this.Values);
    for (int i = 0; i < this.Count; i++) {
      Bullet currentKey = keyList[i];
      array.SetValue( currentKey, arrayIndex+i);
    }
  }

  global::System.Collections.Generic.IEnumerator< Bullet> global::System.Collections.Generic.IEnumerable<Bullet>.GetEnumerator() {
    return new BulletPtrSetEnumerator(this);
  }

  global::System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
    return new BulletPtrSetEnumerator(this);
  }

  public BulletPtrSetEnumerator GetEnumerator() {
    return new BulletPtrSetEnumerator(this);
  }

  // Type-safe enumerator
  /// Note that the IEnumerator documentation requires an InvalidOperationException to be thrown
  /// whenever the collection is modified. This has been done for changes in the size of the
  /// collection but not when one of the elements of the collection is modified as it is a bit
  /// tricky to detect unmanaged code that modifies the collection under our feet.
  public sealed class BulletPtrSetEnumerator : global::System.Collections.IEnumerator, 
      global::System.Collections.Generic.IEnumerator< Bullet>
  {
    private BulletPtrSet collectionRef;
    private global::System.Collections.Generic.IList<Bullet> keyCollection;
    private int currentIndex;
    private object currentObject;
    private int currentSize;

    public BulletPtrSetEnumerator(BulletPtrSet collection) {
      collectionRef = collection;
      keyCollection = new global::System.Collections.Generic.List<Bullet>(collection.Values);
      currentIndex = -1;
      currentObject = null;
      currentSize = collectionRef.Count;
    }

    // Type-safe iterator Current
    public  Bullet Current {
      get {
        if (currentIndex == -1)
          throw new global::System.InvalidOperationException("Enumeration not started.");
        if (currentIndex > currentSize - 1)
          throw new global::System.InvalidOperationException("Enumeration finished.");
        if (currentObject == null)
          throw new global::System.InvalidOperationException("Collection modified.");
        return ( Bullet)currentObject;
      }
    }

    // Type-unsafe IEnumerator.Current
    object global::System.Collections.IEnumerator.Current {
      get {
        return Current;
      }
    }

    public bool MoveNext() {
      int size = collectionRef.Count;
      bool moveOkay = (currentIndex+1 < size) && (size == currentSize);
      if (moveOkay) {
        currentIndex++;
        currentObject = keyCollection[currentIndex];
      } else {
        currentObject = null;
      }
      return moveOkay;
    }

    public void Reset() {
      currentIndex = -1;
      currentObject = null;
	  if (collectionRef.Count != currentSize) {
        throw new global::System.InvalidOperationException("Collection modified.");
      }
    }

    public void Dispose() {
      currentIndex = -1;
      currentObject = null;
    }
  }
#endif
  

  public BulletPtrSet() : this(bwapiPINVOKE.new_BulletPtrSet__SWIG_0(), true) {
  }

  public BulletPtrSet(BulletPtrSet other) : this(bwapiPINVOKE.new_BulletPtrSet__SWIG_1(BulletPtrSet.getCPtr(other)), true) {
    if (bwapiPINVOKE.SWIGPendingException.Pending) throw bwapiPINVOKE.SWIGPendingException.Retrieve();
  }

  private uint size() {
    uint ret = bwapiPINVOKE.BulletPtrSet_size(swigCPtr);
    return ret;
  }

  public bool empty() {
    bool ret = bwapiPINVOKE.BulletPtrSet_empty(swigCPtr);
    return ret;
  }

  public void Clear() {
    bwapiPINVOKE.BulletPtrSet_Clear(swigCPtr);
  }

  public Bullet getitem(Bullet key) {
    global::System.IntPtr cPtr = bwapiPINVOKE.BulletPtrSet_getitem(swigCPtr, Bullet.getCPtr(key));
    Bullet ret = (cPtr == global::System.IntPtr.Zero) ? null : new Bullet(cPtr, false);
    if (bwapiPINVOKE.SWIGPendingException.Pending) throw bwapiPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public bool ContainsKey(Bullet key) {
    bool ret = bwapiPINVOKE.BulletPtrSet_ContainsKey(swigCPtr, Bullet.getCPtr(key));
    return ret;
  }

  public void Add(Bullet key) {
    bwapiPINVOKE.BulletPtrSet_Add(swigCPtr, Bullet.getCPtr(key));
    if (bwapiPINVOKE.SWIGPendingException.Pending) throw bwapiPINVOKE.SWIGPendingException.Retrieve();
  }

  public bool Remove(Bullet key) {
    bool ret = bwapiPINVOKE.BulletPtrSet_Remove(swigCPtr, Bullet.getCPtr(key));
    return ret;
  }

  public global::System.IntPtr create_iterator_begin() {
    global::System.IntPtr ret = bwapiPINVOKE.BulletPtrSet_create_iterator_begin(swigCPtr);
    return ret;
  }

  public Bullet get_next_key(global::System.IntPtr swigiterator) {
    global::System.IntPtr cPtr = bwapiPINVOKE.BulletPtrSet_get_next_key(swigCPtr, swigiterator);
    Bullet ret = (cPtr == global::System.IntPtr.Zero) ? null : new Bullet(cPtr, false);
    if (bwapiPINVOKE.SWIGPendingException.Pending) throw bwapiPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

}

}
