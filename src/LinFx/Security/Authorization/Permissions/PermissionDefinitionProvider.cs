﻿namespace LinFx.Security.Authorization.Permissions
{
    public abstract class PermissionDefinitionProvider : IPermissionDefinitionProvider
    {
        public abstract void Define(IPermissionDefinitionContext context);
    }
}