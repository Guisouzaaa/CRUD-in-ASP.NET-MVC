using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUDControleDeEstoque.Models;
using CRUDControleDeEstoque.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CRUDControleDeEstoque.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<UsuarioModel> userManager;
        private SignInManager<UsuarioModel> signInManager;

        public AccountController(UserManager<UsuarioModel> _userManager, SignInManager<UsuarioModel> _signInManager)
        {
            userManager = _userManager;
            signInManager = _signInManager;
        }

        public IActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(AccountViewModel conta, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                UsuarioModel usuario = await userManager.FindByEmailAsync(conta.Email);
                if (usuario != null)
                {
                    await signInManager.SignOutAsync();
                    var resultado = await signInManager.PasswordSignInAsync(usuario, conta.Senha, false, false);
                    if (resultado.Succeeded)
                    {
                        return Redirect(returnUrl ?? "/");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Email ou senha incorreto.");
                    }
                }
            }
            return View(conta);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registrar(UsuarioViewModel uvm)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(uvm.Email);
                if (user != null)
                {
                    ModelState.AddModelError("Email", "Este e-mail já está sendo usado");
                }
                else
                {
                    UsuarioModel usuario = new UsuarioModel
                    {
                        UserName = uvm.Nome,
                        Email = uvm.Email
                    };
                    if(usuario != null)
                    {
                        var resultado = await userManager.CreateAsync(usuario, uvm.Senha);
                        if (resultado.Succeeded)
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                }
            }
            return View(uvm);
        }


        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}