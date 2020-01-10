﻿using Entities;
using Infra.IRepository.Dapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Repository.Dapper
{
    public class BanknoteDapperRepository : DapperRepository<Banknote>, IBanknoteDapperRepository
    {
    }
}