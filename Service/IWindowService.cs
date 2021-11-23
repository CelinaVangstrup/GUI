using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST3PRJ3.Service
{
    /// <summary>
    /// Interface for oprettelse af et nyt vindue
    /// </summary>
    interface IWindowService
    {
        void CreateWindow();
        void CloseWindow();
    }
}
