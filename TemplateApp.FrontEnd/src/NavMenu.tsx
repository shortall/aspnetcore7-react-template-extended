import styles from './NavMenu.module.css';
import { CssModuleNameComposer } from "./cssModuleNameComposer";
import React, { useState } from 'react';
import { NavLink } from 'react-router-dom';

export const NavMenu: React.FC = () => {

    const [collapseNavMenu, setCollapseNavMenu] = useState(true);

    let cn = new CssModuleNameComposer(styles).composeNames;

    function navLinkClassNames(isActive: boolean, isPending: boolean) {
        let classNames = "nav-link";

        return classNames + (isPending ? " pending" : isActive ? " active" : "");
    }

    function toggleNavMenu() {
        setCollapseNavMenu(!collapseNavMenu);
    }

    return (
        <>
            <div className={cn(["top-row", "ps-3", "navbar", "navbar-dark"])} >
                <div className={cn(["container-fluid"])}>
                    <a className={cn(["navbar-brand"])} href="">ReactApp1</a>
                    <button title="Navigation menu" className={cn(["navbar-toggler"])} onClick={toggleNavMenu} >
                        <span className={cn(["navbar-toggler-icon"])}></span>
                    </button>
                </div>
            </div >

            <div className={collapseNavMenu ? cn(["collapse", "nav-scrollable"]) : cn(["nav-scrollable"])} onClick={toggleNavMenu}>
                <nav className={cn(["flex-column"])}>
                    <div className={cn(["nav-item", "px-3"])}>
                        <NavLink className={({ isActive, isPending }) => navLinkClassNames(isActive, isPending)} to="/" >
                            <span className={cn(["oi", "oi-home"])} aria-hidden="true"></span> Home
                        </NavLink>
                    </div>
                    <div className={cn(["nav-item", "px-3"])}>
                        <NavLink className={({ isActive, isPending }) => navLinkClassNames(isActive, isPending)} to="/counter">
                            <span className={cn(["oi", "oi-plus"])} aria-hidden="true"></span> Counter
                        </NavLink>
                    </div>
                    <div className={cn(["nav-item", "px-3"])}>
                        <NavLink className={({ isActive, isPending }) => navLinkClassNames(isActive, isPending)} to="/fetchdata" >
                            <span className={cn(["oi", "oi-list-rich"])} aria-hidden="true"></span> Fetch data
                        </NavLink>
                    </div>
                </nav>
            </div >
        </>
    );
};

