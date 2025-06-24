using AutoMapper;
using Nutrifit.Domain.DTos;
using Nutrifit.Domain.DTos.Base;
using Nutrifit.Domain.Entities;
using Nutrifit.Domain.Interfaces.Application.Services;
using Nutrifit.Domain.Interfaces.Infra.Data.Repositories;
using Nutrifit.Infra.CrossCutting.DI;

namespace Nutrifit.Service.Services
{
    public class UsuarioService : IUsuarioService, IScopedDependency
    {
        private readonly IMapper _mapper;
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioService(IMapper mapper, IUsuarioRepository usuarioRepository)
        {
            _mapper = mapper;
            _usuarioRepository = usuarioRepository;
        }

        #region Private Methods
        #endregion

        #region Public Methods

        public async Task<Usuario> InserirUsuario(UsuarioDTo model)
        {
            try
            {
                var usuario = _mapper.Map<Usuario>(model);
                return await _usuarioRepository.InserirUsuario(usuario);
            }
            catch(Exception ex) 
            {
                throw new Exception($"Erro ao inserir usuario: {ex.Message}");
            }          
        }

        public async Task<List<Usuario>> BuscarUsuarios()
        {
            try
            {
                return (await _usuarioRepository.BuscarUsuarios()).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao buscar usuarios: {ex.Message}");
            }          
        }

        public async Task<UsuarioDTo?> BuscarUsuarioPorId(long id)
        {
            try
            {
                var usuario = await _usuarioRepository.BuscarUsuarioId(id);
                return _mapper.Map<UsuarioDTo>(usuario);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao buscar usuario: {ex.Message}");
            }
        }

        public async Task<Usuario> AtualizarUsuario(UpdateBaseDTo model)
        {
            try
            {
                var usuario = _mapper.Map<Usuario>(model);
                return await _usuarioRepository.AtualizarUsuario(usuario);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao atualizar usuario: {ex.Message}");
            }          
        }
     
        public async Task<bool> ExcluirUsuario(long usuarioId)
        {
            try
            {
                return await _usuarioRepository.ExcluirUsuario(usuarioId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao excluir usuario: {ex.Message}");
            }          
        }
      
        #endregion

    }
}
