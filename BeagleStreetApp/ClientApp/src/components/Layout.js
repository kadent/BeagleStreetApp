const Layout = ({ children, title }) => {
    return (
        <div className="container py-4 d-flex flex-column align-items-center">
            {title && <h1 className="mb-5">{title}</h1>}
            {children}
        </div>
    );
};

export default Layout;