using System;

namespace Session08.Entities
{
    public interface IAuditable01
    {

    }
    public interface IAuditable
    {
        int InsertBy { get; set; }
        int UpdateBy { get; set; }
        DateTime InsertDate { get; set; }
        DateTime UpdateDate { get; set; }
    }
}
