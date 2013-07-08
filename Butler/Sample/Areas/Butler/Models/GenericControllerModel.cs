using System;
using System.Collections.Generic;

public class GenericControllerModel
{

    public string Name { get; set; }
    public Type Type { get; set; }
    public List<dynamic> Entities { get; set; }
}