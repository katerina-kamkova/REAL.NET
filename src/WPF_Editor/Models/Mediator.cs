﻿using System;
using Repo;
using WPF_Editor.Models.Console;
using WPF_Editor.Models.Interfaces;
using WPF_Editor.ViewModels;

namespace WPF_Editor.Models
{
    /* This class provides connection between components like palette, console, toolbar, etc.
       Now there are only palette and scene.
       if you add a new component, class has to implement IComponentNameMediator and a component has to implement IComponentName.
       At least there's has to be one connection(interface reference) from one to another.
       It has to be defined in IComponentName or IComponentNameMediator interface.
       Each component like palette, for example, has to be defined once.
       You can do it using private constructor and special static method CreateComponent. See Scene implementation.*/
    public class Mediator : ISceneMediator, IPaletteMediator
    {
        private static Mediator _mediator;

        private IScene Scene { get; }

        private IPalette Palette { get; }


        public static Mediator CreateMediator()
        {
            if (_mediator is null)
            {
                _mediator = new Mediator();
            }
            return _mediator;
        }

        public IElement GetSelectedPaletteItem()
        {
            return Palette.SelectedElement;
        }

        private Mediator()
        {
            /* Property this.Scene and class' name are the same. So there's need in full path to class Scene.*/
            Scene = Models.Scene.CreateScene(this);
            /* Property this.Palette and class' name are the same. So there's need in full path to class Palette.*/
            Palette = Models.Palette.CreatePalette(this);
        }

    }
}
