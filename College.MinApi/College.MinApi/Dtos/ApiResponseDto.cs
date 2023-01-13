﻿namespace College.MinApi.Dtos
{

    public record ApiResponseDto<T>
    {
        public bool Success { get; set; }

        public string? Message { get; set; }

        public T? Data { get; set; }
    }

}
