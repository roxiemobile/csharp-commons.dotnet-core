using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RoxieMobile.CSharpCommons.Abstractions.Models;
using RoxieMobile.CSharpCommons.Diagnostics;
using RoxieMobile.CSharpCommons.Extensions;

namespace RoxieMobile.CSharpCommons.Data.Serialization.Json
{
    public class PostValidatableContractResolver : DefaultContractResolver
    {
        protected override JsonContract CreateContract(Type objectType)
        {
            return base.CreateContract(objectType).Tap(
                contract => contract.OnDeserializedCallbacks.Add((obj, _) => {

                    if (obj is IPostValidatable instance && instance.IsShouldPostValidate()) {
                        try {
                            instance.Validate();
                        }
                        catch (CheckException e) {
                            throw new JsonSerializationException(e.Message, e);
                        }
                    }
                }));
        }
    }
}