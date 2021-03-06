﻿using Boa.Constrictor.Screenplay;
using OpenQA.Selenium;

namespace Boa.Constrictor.WebDriver
{
    /// <summary>
    /// Maximizes the browser window.
    /// </summary>
    public class MaximizeWindow : AbstractWebTask
    {
        #region Constructors

        /// <summary>
        /// Private constructor.
        /// (Use static builder methods to construct.)
        /// </summary>
        private MaximizeWindow() { }

        #endregion

        #region Builder Methods

        /// <summary>
        /// Constructs the task object.
        /// </summary>
        /// <returns></returns>
        public static MaximizeWindow ForBrowser() => new MaximizeWindow();

        #endregion

        #region Methods

        /// <summary>
        /// Maximizes the browser window.
        /// </summary>
        /// <param name="actor">The screenplay actor.</param>
        /// <param name="driver">The WebDriver.</param>
        public override void PerformAs(IActor actor, IWebDriver driver) =>
            driver.Manage().Window.Maximize();

        /// <summary>
        /// Returns a description of the question.
        /// </summary>
        /// <returns></returns>
        public override string ToString() => $"Maximize browser window";

        #endregion
    }
}
