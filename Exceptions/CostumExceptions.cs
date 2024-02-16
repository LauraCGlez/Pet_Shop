using System;

namespace pet_shop.Exceptions;
public class DuplicationException: Exception
{
    //SALTA UNA EXCEPCION CUANDO EL DNI DEL USUARIO YA ESTÁ REGISTRADO
    public DuplicationException(string message) : base(message) { }
}
