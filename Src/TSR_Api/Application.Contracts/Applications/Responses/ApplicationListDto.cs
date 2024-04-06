﻿using Application.Contracts.Converter.Converter;
using Application.Contracts.Dtos.Enums;
using Application.Contracts.TimeLineDTO;
using Newtonsoft.Json;

namespace Application.Contracts.Applications.Responses
{
    public class ApplicationListDto
    {
        public Guid Id { get; set; }
        public Guid ApplicantId { get; set; }
        public string Username { get; set; }
        public string CoverLetter { get; set; }
        public Guid VacancyId { get; set; }
        public string VacancyTitle { get; set; }
        public int StatusId { get; set; }
        public string StatusName { get; set; }
        public string Slug { get; set; }
        public DateTime CreatedAt { get; set; }
        public IEnumerable<VacancyResponseDto> VacancyResponses { get; set; }
        public IEnumerable<TaskResponseDto> TaskResponses { get; set; }
        public string CV { get; set; }
    }

    public class ApplicationDetailsDto
    {
        public Guid Id { get; set; }

        public Guid ApplicantId { get; set; }
        public string CoverLetter { get; set; }
        public Guid VacancyId { get; set; }
        public int StatusId { get; set; }

        [JsonConverter(typeof(DateTimeToUnixConverter))]
        public DateTime CreatedAt { get; set; }

        public Guid? CreatedBy { get; set; }

        [JsonConverter(typeof(DateTimeToUnixConverter))]
        public DateTime? LastModifiedAt { get; set; }

        public Guid? LastModifiedBy { get; set; }

        public IEnumerable<TimeLineDetailsDto> History { get; set; }
        public string Slug { get; set; }
        public string CV { get; set; }
        public IEnumerable<VacancyResponseDto> VacancyResponses { get; set; }
        public IEnumerable<TaskResponseDto> TaskResponses { get; set; }
    }

    public class ApplicationListStatus
    {
        public Guid Id { get; set; }
        public Guid ApplicantId { get; set; }
        public Guid VacancyId { get; set; }
        public string VacancyTitle { get; set; }
        public ApplicationStatusDto.ApplicationStatus Status { get; set; }
    }
}