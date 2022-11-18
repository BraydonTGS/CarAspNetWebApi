using System;
using System.Collections.Generic;

namespace CarsAPI.EF;

public partial class Model
{
    public int ModelId { get; set; }

    public int MakeId { get; set; }

    public string? ModelName { get; set; }
}
