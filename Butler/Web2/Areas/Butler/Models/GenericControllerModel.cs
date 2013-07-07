using System;
using System.Collections.Generic;

public class GenericControllerModel<T>
{

    public GenericControllerModel()
    {
        this.Type = typeof(T);
    }

    public string Name { get; set; }
    public Type Type { get; set; }
    public List<T> Entities { get; set; }
}