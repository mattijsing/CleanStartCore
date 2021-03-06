﻿using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Application.Intermediaries.Queries.GetIntermediariesList;
using Application.Intermediaries.Queries.GetIntermediaryDetail;
using Application.Intermediaries.Commands.UpdateIntermediary;
using Application.Intermediaries.Commands.CreateIntermediary;
using Application.Intermediaries.Commands.DeleteIntermediary;
using System.Net;

namespace WebAPI.Controllers
{
    public class IntermediariesController : BaseController
    {
        // GET api/Intermediaries
        [HttpGet]
        public async Task<ActionResult<IntermediariesListViewModel>> GetAll()
        {
            return Ok(await Mediator.Send(new GetIntermediariesListQuery()));
        }

        // GET api/Intermediaries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IntermediaryDetailModel>> Get(string id)
        {
            return Ok(await Mediator.Send(new GetIntermediaryDetailQuery { Id = id }));
        }

        // POST api/Intermediaries
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Create([FromBody]CreateIntermediaryCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        // PUT api/Intermediaries/5
        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Update(string id, [FromBody]UpdateIntermediaryCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        // DELETE api/Intermediaries/5
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(string id)
        {
            await Mediator.Send(new DeleteIntermediaryCommand { Id = id });

            return NoContent();
        }
    }
}