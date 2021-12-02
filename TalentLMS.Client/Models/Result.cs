using System;

namespace TalentLMS.Client.Models
{
    public class Result<T>
    {
        private Result(Exception e)
        {
            Exception = e;
        }

        private Result(T payload)
        {
            Payload = payload;
        }

        public T Payload { get; }

        public bool HasException => Exception != null;

        public Exception Exception { get; }

        public static Result<T> Fail(Exception e)
        {
            return new Result<T>(e);
        }

        public static Result<T> Success(T payload)
        {
            return new Result<T>(payload);
        }

        public static implicit operator bool(Result<T> result)
        {
            return result.HasException;
        }

        public override string ToString()
        {
            return HasException ? $"Exception: {Exception}" : $"Payload: {Payload}";
        }
    }

    public class Result
    {
        private Result(Exception e)
        {
            Exception = e;
        }

        private Result()
        {
            Exception = null;
        }

        public Exception Exception { get; }

        public bool HasException => Exception != null;

        public static Result Success => new Result();

        public static Result Fail(Exception e)
        {
            return new Result(e);
        }

        public static implicit operator bool(Result result)
        {
            return result.HasException;
        }

        public override string ToString()
        {
            return HasException ? $"{Exception}" : string.Empty;
        }
    }
}