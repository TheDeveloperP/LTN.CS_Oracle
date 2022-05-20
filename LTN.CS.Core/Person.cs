using System;
using System.Collections.Generic;
using System.Text;
using IBatisNetLib;


namespace LTN.CS.Core
{
    /// <summary>
    /// ≤‚ ‘ µÃÂ
    /// </summary>
[Serializable]
    public class Person : BaseEntity
{

    public int Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string BirthDate { get; set; }

    public double? WeightInKilograms { get; set; }

    public double? HeightInMeters { get; set; }


    public override string ToString()
    {
        StringBuilder str = new StringBuilder();
        str.Append(String.Format("this person's FirstName is {0}\n", this.FirstName));
        str.Append(String.Format("this person's LastName is {0}\n", this.LastName));
        str.Append(String.Format("this person's WeightInKilograms is {0}\n", this.WeightInKilograms));
        str.Append(String.Format("this person's HeightInMeters is {0}\n", this.HeightInMeters));
        return str.ToString(); ;
    }
}

}
