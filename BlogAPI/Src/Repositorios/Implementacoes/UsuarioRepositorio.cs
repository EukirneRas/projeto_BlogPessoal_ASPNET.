using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogAPI.Src.Contextos;
using BlogAPI.Src.Modelos;
using Microsoft.EntityFrameworkCore;

namespace BlogAPI.Src.Repositorios.Implementacoes
{
    /// <summary>
    /// <para>Resumo: Classe responsavel por implementar IUsuario</para>
    /// <para>Criado por: Generation</para>
    /// <para>Versão: 1.0</para>
    /// <para>Data: 12/05/2022</para>
    /// </summary>
    public class UsuarioRepositorio : IUsuario
    {
        #region Atributos
        private readonly BlogPessoalContexto _contexto;
        #endregion
        #region Construtores
        public UsuarioRepositorio(BlogPessoalContexto contexto)
        {
            _contexto = contexto;
        }

        #endregion
        /// <summary>
        /// <para>Resumo: Método assíncrono para pegar um usuario pelo email</para>
        /// </summary>
        /// <param name="email">Email do usuario</param>
        /// <return>UsuarioModelo</return>
        public async Task<Usuario> PegarUsuarioPeloEmailAsync(string email)
        {
            return await _contexto.Usuarios.FirstOrDefaultAsync(u => u.Email == email);
        }

        /// <summary>
        /// <para>Resumo: Método assíncrono para salvar um novo usuario</para>
        /// </summary>
        /// <param name="usuario">Construtor para cadastrar usuario</param>
        public async Task NovoUsuarioAsync(Usuario usuario)
        {
            await _contexto.Usuarios.AddAsync(
            new Usuario
            {
                Nome = usuario.Nome,
                Email = usuario.Email,
                Senha = usuario.Senha,
                Foto = usuario.Foto,
                Tipo = usuario.Tipo
            }
            );
            await _contexto.SaveChangesAsync();
        }
    }
}

