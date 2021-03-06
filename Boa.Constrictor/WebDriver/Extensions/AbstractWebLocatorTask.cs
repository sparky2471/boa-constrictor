﻿using Boa.Constrictor.Screenplay;
using Boa.Constrictor.Utilities;
using OpenQA.Selenium;

namespace Boa.Constrictor.WebDriver
{
    /// <summary>
    /// Abstract class for any Web tasks that use a Web element locator.
    /// </summary>
    public abstract class AbstractWebLocatorTask : AbstractWebTask, IWebLocatorUser
    {
        #region Constructors

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="locator">The target Web element's locator.</param>
        public AbstractWebLocatorTask(IWebLocator locator) => Locator = locator;

        #endregion

        #region Properties

        /// <summary>
        /// The adjective to use for the Locator in the ToString method.
        /// </summary>
        protected virtual string ToStringAdjective => "on";

        /// <summary>
        /// The target Web element's locator.
        /// </summary>
        public IWebLocator Locator { get; }

        #endregion

        #region Methods

        /// <summary>
        /// Attempts the task.
        /// Internally calls RequestAs with the WebDriver from the BrowseTheWeb ability.
        /// Internally retries the interaction if StaleElementReferenceException happens.
        /// </summary>
        /// <param name="actor">The screenplay actor.</param>
        public override void PerformAs(IActor actor)
        {
            bool attempt()
            {
                PerformAs(actor, actor.Using<BrowseTheWeb>().WebDriver);
                return true;
            }
                
            Retries.RetryOnException<StaleElementReferenceException, bool>(attempt, ToString(), logger: actor.Logger);
        }

        /// <summary>
        /// Returns a description of the task.
        /// </summary>
        /// <returns></returns>
        public override string ToString() =>
            $"{GetType().Name} {ToStringAdjective} '{Locator.Description}'";

        #endregion
    }
}
