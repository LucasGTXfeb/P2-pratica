using System;
using System.Text.RegularExpressions;

namespace LojaVirtual.Entities
{
    public class Cliente : ICliente
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Cpf { get; private set; }

        public Cliente(int id, string nome, string email, string cpf)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome inválido.");
            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                throw new ArgumentException("Email inválido.");
            if (!Regex.IsMatch(cpf, @"^\d{11}$"))
                throw new ArgumentException("CPF deve conter 11 dígitos numéricos.");

            Id = id;
            Nome = nome;
            Email = email;
            Cpf = cpf;
        }
    }
}