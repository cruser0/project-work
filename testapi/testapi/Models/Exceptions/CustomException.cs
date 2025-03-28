namespace API.Models.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException()
        {
        }

        public NotFoundException(string message)
            : base(message)
        {
        }

        public NotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }

    public class NullPropertyException : Exception
    {
        public NullPropertyException()
        {
        }

        public NullPropertyException(string message)
            : base(message)
        {
        }

        public NullPropertyException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }

    public class ErrorInputPropertyException : Exception
    {
        public ErrorInputPropertyException()
        {
        }

        public ErrorInputPropertyException(string message)
            : base(message)
        {
        }

        public ErrorInputPropertyException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }

    public class NotFoundTokenException : Exception
    {
        public NotFoundTokenException()
        {
        }

        public NotFoundTokenException(string message)
            : base(message)
        {
        }

        public NotFoundTokenException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }

    public class UpdateException : Exception
    {
        public UpdateException()
        {
        }

        public UpdateException(string message)
            : base(message)
        {
        }

        public UpdateException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }

}
