﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRun.Application.RunnerProfile.Query.GetRunnerProfile
{
    public class GetRunnerProfileQuery: IRequest<RunnerProfileDto>
    {
        public int _id { get; set; }

        public GetRunnerProfileQuery(int id)
        {
            _id = id;
        }
    }
}
