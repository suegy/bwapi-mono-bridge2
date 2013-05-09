%{
#include <set>
#include <algorithm>
#include <stdexcept>
%}

/* K is the C++ key type, T is the C++ value type */
%define SWIG_STD_SET_INTERNAL(T)

%typemap(csinterfaces) std::set< T > "IDisposable \n#if !SWIG_DOTNET_1\n    , System.Collections.Generic.ICollection<$typemap(cstype, T)>\n#endif\n";
%typemap(cscode) std::set< T > %{

  
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
 public System.Collections.Generic.ICollection<$typemap(cstype, T)> Values {
    get {
      System.Collections.Generic.ICollection<$typemap(cstype, T)> values = new System.Collections.Generic.List<$typemap(cstype, T)>();
      IntPtr iter = create_iterator_begin();
      try {
        while (true) {
          values.Add(get_next_key(iter));
        }
      } catch (ArgumentOutOfRangeException) {
      }
      return values;
    }
  }
 
  public bool Contains($typemap(cstype, T) item) {
    if ( ContainsKey(item)) {
      return true;
    } else {
      return false;
    }
  }

  public void CopyTo($typemap(cstype, T)[] array) {
    CopyTo(array, 0);
  }

  public void CopyTo( $typemap(cstype, T)[] array, int arrayIndex) {
    if (array == null)
      throw new ArgumentNullException("array");
    if (arrayIndex < 0)
      throw new ArgumentOutOfRangeException("arrayIndex", "Value is less than zero");
    if (array.Rank > 1)
      throw new ArgumentException("Multi dimensional array.", "array");
    if (arrayIndex+this.Count > array.Length)
      throw new ArgumentException("Number of elements to copy is too large.");

   System.Collections.Generic.IList<$typemap(cstype, T)> keyList = new System.Collections.Generic.List<$typemap(cstype, T)>(this.Values);
    for (int i = 0; i < this.Count; i++) {
      $typemap(cstype, T) currentKey = keyList[i];
      array.SetValue( currentKey, arrayIndex+i);
    }
  }

  System.Collections.Generic.IEnumerator< $typemap(cstype, T)> System.Collections.Generic.IEnumerable<$typemap(cstype, T)>.GetEnumerator() {
    return new $csclassnameEnumerator(this);
  }

  System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
    return new $csclassnameEnumerator(this);
  }

  public $csclassnameEnumerator GetEnumerator() {
    return new $csclassnameEnumerator(this);
  }

  // Type-safe enumerator
  /// Note that the IEnumerator documentation requires an InvalidOperationException to be thrown
  /// whenever the collection is modified. This has been done for changes in the size of the
  /// collection but not when one of the elements of the collection is modified as it is a bit
  /// tricky to detect unmanaged code that modifies the collection under our feet.
  public sealed class $csclassnameEnumerator : System.Collections.IEnumerator, 
      System.Collections.Generic.IEnumerator< $typemap(cstype, T)>
  {
    private $csclassname collectionRef;
    private System.Collections.Generic.IList<$typemap(cstype, T)> keyCollection;
    private int currentIndex;
    private object currentObject;
    private int currentSize;

    public $csclassnameEnumerator($csclassname collection) {
      collectionRef = collection;
      keyCollection = new System.Collections.Generic.List<$typemap(cstype, T)>(collection.Values);
      currentIndex = -1;
      currentObject = null;
      currentSize = collectionRef.Count;
    }

    // Type-safe iterator Current
    public  $typemap(cstype, T) Current {
      get {
        if (currentIndex == -1)
          throw new InvalidOperationException("Enumeration not started.");
        if (currentIndex > currentSize - 1)
          throw new InvalidOperationException("Enumeration finished.");
        if (currentObject == null)
          throw new InvalidOperationException("Collection modified.");
        return ( $typemap(cstype, T))currentObject;
      }
    }

    // Type-unsafe IEnumerator.Current
    object System.Collections.IEnumerator.Current {
      get {
        return Current;
      }
    }

    public bool MoveNext() {
      int size = collectionRef.Count;
      bool moveOkay = (currentIndex+1 < size) && (size == currentSize);
      if (moveOkay) {
        currentIndex++;
        $typemap(cstype, T) currentKey = keyCollection[currentIndex];
        currentObject = currentKey;
      } else {
        currentObject = null;
      }
      return moveOkay;
    }

    public void Reset() {
      currentIndex = -1;
      currentObject = null;
      if (collectionRef.Count != currentSize) {
        throw new InvalidOperationException("Collection modified.");
      }
    }

    public void Dispose() {
      currentIndex = -1;
      currentObject = null;
    }
  }
#endif
  
%}

  public:
    set();
    set(const set< T > &other);

    typedef T key_type;
   // typedef T mapped_type;
    typedef size_t size_type;
    size_type size() const;
    bool empty() const;
    %rename(Clear) clear;
    void clear();
    %extend {
      const key_type& getitem(const key_type& key) throw (std::out_of_range) {
        std::set< T >::iterator iter = $self->find(key);
        if (iter != $self->end())
          return *iter;
        else
          throw std::out_of_range("key not found");
      }

      bool ContainsKey(const key_type& key) {
        std::set< T >::iterator iter = $self->find(key);
        return iter != $self->end();
      }

      void Add(const key_type& key) throw (std::out_of_range) {
        std::set< T >::iterator iter = $self->find(key);
        if (iter != $self->end())
          throw std::out_of_range("key already exists");
        $self->insert(key);
      }

      bool Remove(const key_type& key) {
        std::set< T >::iterator iter = $self->find(key);
        if (iter != $self->end()) {
          $self->erase(iter);
          return true;
        }                
        return false;
      }
      
       // create_iterator_begin() and get_next_key() work together to provide a collection of keys to C#
      %apply void *VOID_INT_PTR { std::set< T >::iterator *create_iterator_begin }
      %apply void *VOID_INT_PTR { std::set< T >::iterator *swigiterator }

      std::set< T >::iterator *create_iterator_begin() {
        return new std::set< T >::iterator($self->begin());
      }

      const key_type& get_next_key(std::set< T >::iterator *swigiterator) throw (std::out_of_range) {
        std::set< T >::iterator iter = *swigiterator;
        if (iter == $self->end()) {
          delete swigiterator;
          throw std::out_of_range("no more set elements");
        }
        (*swigiterator)++;
        return (*iter);
      }
    }


%enddef

%csmethodmodifiers std::set::size "private"

// Default implementation
namespace std {   
  template<class T> class set {    
    SWIG_STD_SET_INTERNAL(T)
  };
}


