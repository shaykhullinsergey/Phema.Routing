﻿using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace Phema.Routing
{
	internal sealed class ParameterModelConvention : IParameterModelConvention
	{
		private readonly RoutingOptions options;

		public ParameterModelConvention(RoutingOptions options)
		{
			this.options = options;
		}

		public void Apply(ParameterModel parameter)
		{
			if (!options.Parameters.TryGetValue(parameter.ParameterInfo, out var metadata))
			{
				return;
			}

			if (parameter.BindingInfo == null)
			{
				parameter.BindingInfo = new BindingInfo();
			}

			if (metadata.ModelName != null)
			{
				parameter.BindingInfo.BinderModelName = metadata.ModelName;
			}

			parameter.BindingInfo.BindingSource = metadata.BindingSource;

			// TODO: parameter.BindingInfo.BinderType = metadata.BinderType;
		}
	}
}
