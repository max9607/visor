using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PLVISORTELERIK.Helpers
{
    public class MostrarMensajes : IMostrarMensajes
    {
        public bool modoDark = true;
        private readonly IJSRuntime js;

        public MostrarMensajes(IJSRuntime js)
        {
            this.js = js;
        }

        public async Task MostrarMensajeError(string mensaje)
        {
            await asignarThema();
            await MostrarMensaje("Error", mensaje, "error", modoDark);
        }

        public async Task MostrarMensajeExitoso(string mensaje)
        {
            await asignarThema();
            await MostrarMensaje("Exitoso", mensaje, "success", modoDark);


        }

        private async ValueTask MostrarMensaje(string titulo, string mensaje, string tipoMensaje, bool theme)
        {
            await js.InvokeVoidAsync("alerta", titulo, mensaje, tipoMensaje, theme);
        }
        public async Task<bool> Confirmacion(string titulo, string mensaje, string icono)
        {
            await asignarThema();
            var confirmacion = await js.InvokeAsync<bool>("confirmar", titulo, mensaje, icono, modoDark);

            return confirmacion;
        }

        [JSInvokable]
        public async Task asignarThema()
        {
            var modo = await js.GetFromLocalStorage("theme");
            if (modo == "dark")
            {
                modoDark = true;
            }
            else
            {
                modoDark = false;
            }
        }

    }
}
