import styles from './Layout.module.css';
import { CssModuleNameComposer } from "./cssModuleNameComposer";
import { Outlet } from "react-router-dom";
import { NavMenu } from "./NavMenu";

export const Layout: React.FC = () => {

    let cn = new CssModuleNameComposer(styles).composeNames;

    return (
        <div className={cn(["page"])}>
            <div className={cn(["sidebar"])}>
                <NavMenu />
            </div>

            <main>
                <div className={cn(["top-row", "px-4"])}>
                    <a href="https://react.dev/" target="_blank">About</a>
                </div>

                <article className={cn(["content", "px-4"])}>
                    <Outlet />
                </article>
            </main>
        </div>
    );
}