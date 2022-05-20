using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Reflection;
using System.Runtime.Serialization;

namespace LTN.CS.Core
{
    [DataContract]
    public class BaseEntity
    {
        [DataMember]
        public int Flag { get; set; }
        [DataMember]
        public int NewID { get; set; }
        [DataMember]
        public string Msg { get; set; }
        [DataMember]
        public DateTime CreateTime { get; set; }
        [DataMember]
        public DateTime UpdateTime { get; set; }
        /// <summary>
        /// Clone the object, and returning a reference to a cloned object.
        /// </summary>
        /// <returns>Reference to the new cloned 
        /// object.</returns>
        public virtual object Clone()
        {
            if (this == null)
            {
                return null;
            }
            //First we create an instance of this specific type.
            object newObject = Activator.CreateInstance(GetType());

            //We get the array of fields for the new type instance.
            PropertyInfo[] fields = newObject.GetType().GetProperties();
            int i = 0;

            foreach (PropertyInfo fi in GetType().GetProperties())
            {
                Type thistype = fi.GetType();
                Object field = thistype.GetConstructor(new Type[0]) == null ? new object() : Activator.CreateInstance(fi.GetType());
                //We query if the fiels support the ICloneable interface.
                //Type ICloneType = .
                //            GetInterface("ICloneable", true);
                MethodInfo cloneMethod = field.GetType().GetMethod("Clone");
                if (cloneMethod != null)
                {

                    //We use the clone method to set the new value to the field.
                    if (fields[i].CanWrite)
                    {
                        fields[i].SetValue(newObject, fi.GetValue(this, null), null);
                    }

                }
                else
                {
                    // If the field doesn't support the ICloneable 
                    // interface then just set it.
                    if (fi.Name != "CLASS_VERSION" && fi.Name != "IsUnique")
                    {
                        if (fields[i].CanWrite)
                        {
                            fields[i].SetValue(newObject, fi.GetValue(this, null), null);
                        }
                    }

                }

                //Now we check if the object support the 
                //IEnumerable interface, so if it does
                //we need to enumerate all its items and check if 
                //they support the ICloneable interface.
                Type IEnumerableType = fi.GetType().GetInterface
                                ("IEnumerable", true);
                if (IEnumerableType != null)
                {
                    //Get the IEnumerable interface from the field.
                    IEnumerable IEnum = (IEnumerable)fi.GetValue(this, null);

                    //This version support the IList and the 
                    //IDictionary interfaces to iterate on collections.
                    Type IListType = fields[i].PropertyType.GetInterface
                                        ("IList", true);
                    Type IDicType = fields[i].PropertyType.GetInterface
                                        ("IDictionary", true);

                    int j = 0;
                    if (IListType != null)
                    {
                        //Getting the IList interface.
                        IList list = (IList)fields[i].GetValue(newObject, null);

                        foreach (object obj in IEnum)
                        {
                            //Checking to see if the current item 
                            //support the ICloneable interface.


                            MethodInfo cloneMethodIEnum = obj.GetType().GetMethod("Clone");
                            if (cloneMethodIEnum != null)
                            {
                                //If it does support the ICloneable interface, 
                                //we use it to set the clone of
                                //the object in the list.
                                BaseEntity clone = (BaseEntity)obj;

                                list[j] = clone.Clone();
                            }

                            //NOTE: If the item in the list is not 
                            //support the ICloneable interface then in the 
                            //cloned list this item will be the same 
                            //item as in the original list
                            //(as long as this type is a reference type).

                            j++;
                        }
                    }
                    else if (IDicType != null)
                    {
                        //Getting the dictionary interface.
                        IDictionary dic = (IDictionary)fields[i].
                                            GetValue(newObject, null);
                        j = 0;

                        foreach (DictionaryEntry de in IEnum)
                        {
                            MethodInfo cloneMethodDictionaryEntry = de.GetType().GetMethod("Clone");
                            if (cloneMethodDictionaryEntry != null)
                            {
                                BaseEntity clone = (BaseEntity)de.Value;
                                dic[de.Key] = clone.Clone();
                            }
                            j++;
                        }
                    }
                }
                i++;
            }
            return newObject;
        }
    }
}
