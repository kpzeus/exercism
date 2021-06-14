using System;

public static class ErrorHandling
{
    public static void HandleErrorByThrowingException()
    {
        throw new Exception();
    }

    public static int? HandleErrorByReturningNullableType(string input)
    {
        int i = 0;
        
        if(int.TryParse(input, out i))
            return i;

        return null;
    }

    public static bool HandleErrorWithOutParam(string input, out int result)
    {
        var r = HandleErrorByReturningNullableType(input);

        if(r != null){
            result = r.Value;
        }  
        else
        {
            result = 0;
        }

        return result != 0;
    }

    public static void DisposableResourcesAreDisposedWhenExceptionIsThrown(IDisposable disposableObject)
    {
        if(disposableObject != null){
            disposableObject.Dispose();
        }

        throw new Exception();
    }
}
