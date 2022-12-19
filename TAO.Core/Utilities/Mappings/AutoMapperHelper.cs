using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using AutoMapper;

namespace TAO.Core.Utilities.Mappings
{
  public static class AutoMapperHelper
  {
    public static List<T> MapToSameTypeList<T>(List<T> list)
    {
      Mapper.Initialize(x =>
      {
        x.CreateMap<T, T>();
      });
      List<T> result = Mapper.Map<List<T>, List<T>>(list);
      return result;
    }
  }
}
