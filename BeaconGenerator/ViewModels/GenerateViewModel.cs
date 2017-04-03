using BeaconGenerator.Models;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeaconGenerator.ViewModels
{
    public class GenerateViewModel
    {
        public GeneratedBeacon Model { get; set; }

        [Required]
        public ReactiveProperty<string> Identifier { get; set; }
        [Required]
        [RegularExpression(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$")]
        public ReactiveProperty<string> Uuid { get; set; }
        [Required]
        [Range(0, 65535)]
        public ReactiveProperty<string> Major { get; set; }
        [Required]
        [Range(0, 65535)]
        public ReactiveProperty<string> Minor { get; set; }
        [Required]
        [Range(0, 255)]
        public ReactiveProperty<string> Power { get; set; }

        public ReactiveCommand CommandRegist { get; set; }

        public GenerateViewModel()
        {
            Model = new GeneratedBeacon();

            Identifier = Model.ToReactivePropertyAsSynchronized(
                m => m.Identifier, 
                ignoreValidationErrorValue: true)
                .SetValidateAttribute(() => this.Identifier);

            Uuid = Model.ToReactivePropertyAsSynchronized(
                m => m.Uuid, 
                ignoreValidationErrorValue: true)
                .SetValidateAttribute(() => this.Uuid);

            Major = Model.ToReactivePropertyAsSynchronized(
                m => m.Major,
                model => model.ToString(),
                view => ushort.Parse(view),
                ignoreValidationErrorValue: true)
                .SetValidateAttribute(() => this.Major);

            Minor = Model.ToReactivePropertyAsSynchronized(
                m => m.Minor,
                model => model.ToString(),
                view => ushort.Parse(view),
                ignoreValidationErrorValue: true)
                .SetValidateAttribute(() => this.Minor);

            Power = Model.ToReactivePropertyAsSynchronized(
                m => m.Power,
                model => model.ToString(),
                view => byte.Parse(view),
                ignoreValidationErrorValue: true)
                .SetValidateAttribute(() => this.Power);

            CommandRegist = new[]
            {
                this.Identifier.ObserveHasErrors,
                this.Uuid.ObserveHasErrors,
                this.Major.ObserveHasErrors,
                this.Minor.ObserveHasErrors,
                this.Power.ObserveHasErrors,
            }
            .CombineLatest(x => x.All(y => !y))
            .ToReactiveCommand();

            CommandRegist.Subscribe(_ => Model.Regist());

        }

    }
}
