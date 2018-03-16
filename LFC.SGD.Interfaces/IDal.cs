using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace LFC.GesDoc.Interfaces
{
    public interface IDal
    {
        IList Listar();
        void Cadastrar(Object obj);
        void Excluir(Object obj);
        void Alterar(Object obj);
    }
}
