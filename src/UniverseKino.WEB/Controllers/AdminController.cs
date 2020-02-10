﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniverseKino.Services.Dto;
using UniverseKino.Services.Interfaces;
using UniverseKino.WEB.Filters;

namespace UniverseKino.WEB
{
    [Route("admin")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    [ServiceFilter(typeof(ExceptionFilter))]
    public class AdminController : ControllerBase
    {
        private readonly IManageMoviesService _manageMovies;
        private readonly IManageSessionsService _manageSessions;
        private readonly IMapper _mapper;

        public AdminController(IManageMoviesService manageMovies, IManageSessionsService manageSessions, IMapper mapper)
        {
            _manageMovies = manageMovies;
            _manageSessions = manageSessions;
            _mapper = mapper;
        }

        [HttpPost("sessions")]
        public async Task<IActionResult> CreateSessinons([FromBody] CreateSessionRequestModel newSession)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sessionDTO = _mapper.Map<CreateSessionDTO>(newSession);

            await _manageSessions.AddAsync(sessionDTO);

            return Ok();
        }

        [HttpDelete("sessions/{id}")]
        public async Task<IActionResult> DeleteSessinons(int id)
        {
            await _manageSessions.RemoveAsync(id);

            return Ok();
        }


        [HttpPost("movies")]
        public async Task<IActionResult> CreateMovies([FromBody] CreateMovieRequestModel newMovie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var movieDTO = _mapper.Map<MovieDTO>(newMovie);

            await _manageMovies.AddAsync(movieDTO);

            return Ok();
        }


        [HttpDelete("movies/{id}")]
        public async Task<IActionResult> DeleteMovies([FromRoute] int id)
        {
            await _manageMovies.RemoveAsync(id);

            return Ok();
        }
    }
}
