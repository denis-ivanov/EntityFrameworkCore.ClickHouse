﻿using Microsoft.EntityFrameworkCore.Storage;

namespace ClickHouse.EntityFrameworkCore.Storage.Internal;

public interface IClickHouseRelationalConnection : IRelationalConnection
{
    IClickHouseRelationalConnection CreateReadOnlyConnection();

    IClickHouseRelationalConnection CreateMasterConnection();
}
