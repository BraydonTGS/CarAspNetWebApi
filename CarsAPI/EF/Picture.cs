using System;
using System.Collections.Generic;

namespace CarsAPI.EF;

public partial class Picture
{
    public int PictureId { get; set; }

    public int CarId { get; set; }

    public string? Path { get; set; }
}
