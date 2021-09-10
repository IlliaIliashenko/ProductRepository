import React,{ useEffect,useState } from 'react'
import { useSelector,useDispatch } from 'react-redux'
import { getProducts,editProduct,createProduct,deleteProduct,selectProducts, getProductByName } from './ProductSlice'
import TokenService from '../User/TokenService'
import classed from './Products.css'

const Products = () => {
    const dispatch = useDispatch()
    const selector = useSelector(selectProducts)
    const [product,setProduct] = useState();
    const [productToAdd,setProductToAdd] = useState();
    const [currentid,setcurrentid] = useState(null);
    const [cardName,setCardName] = useState(null);

    const list = selector.listProducts
    const paging = selector.pagingModel
    const userRoles = TokenService.getUserRoles();
    const isUserAdmin = userRoles.includes("Admin");

    const onSubmit = (e,pageNumber) => {
        e.preventDefault();
        const entity = { innerEntity: product,page: pageNumber }
        dispatch(editProduct(entity))

    }

    const onAdd = (e,pageNumber) => {
        e.preventDefault();
        const entity = { innerEntity: product,page: pageNumber }
        dispatch(createProduct(entity))

    }
    const onDell = (e,id,pageNumber) => {
        e.preventDefault();
        const entity = { innerEntity: id,page: pageNumber }
        dispatch(deleteProduct(entity))

    }
    const findByName = (e) => {
        e.preventDefault();
        dispatch(getProductByName(cardName))
    }

    useEffect(() => {
        dispatch(getProducts())
    },[])


    return (<div>{isUserAdmin && (
        <form onSubmit={(e) => onAdd(e,paging.pageNumber)}>
            <h2>Add new Card</h2>
            <label>
                Name:
                <input onChange={(e) => setProductToAdd({ ...productToAdd,name: e.target.value })} />
            </label>
            <label>
                Price:
                <input onChange={(e) => setProductToAdd({ ...productToAdd,price: e.target.value })} />
            </label>
            <label>
                Quantity:
                <input onChange={(e) => setProductToAdd({ ...productToAdd,quantity: e.target.value })} />
            </label>
            <label>
                Description:
                <input onChange={(e) => setProductToAdd({ ...productToAdd,description: e.target.value })} />
            </label>
            <button type="submit">add</button>
        </form>)}
        <div class="container">
            <h2>Graphic Cards</h2>
            <form onSubmit={findByName}>
                <input onChange={(e) => setCardName({ ...cardName,name: e.target.value })}/>
                <button type="submit">search</button>
            </form>
            <ul class="responsive-table">
                <li class="table-header">
                    <div class="col col-1">Name</div>
                    <div class="col col-2">Price</div>
                    <div class="col col-3">Quantity</div>
                    <div class="col col-4">Description</div>
                    {isUserAdmin && <div class="col col-5">AdminActions</div>}
                </li>
                {list.length === 0 ? <div>No data yet</div> : list.map(data => (
                    currentid === data.id
                        ? (<li class="table-row">
                            <input class="col col-1" data-label="Name" placeholder={data.name} onChange={(e) => setProduct({ ...product,id: data.id,name: e.target.value })} />
                            <input class="col col-2" data-label="Price" placeholder={data.price} onChange={(e) => setProduct({ ...product,id: data.id,price: e.target.value })} />
                            <input class="col col-3" data-label="Quantity" placeholder={data.quantity} onChange={(e) => setProduct({ ...product,id: data.id,quantity: e.target.value })} />
                            <input class="col col-4" data-label="Description" placeholder={data.description} onChange={(e) => setProduct({ ...product,id: data.id,description: e.target.value })} />
                            {isUserAdmin && <button class="col col-5" onClick={(e) => onSubmit(e,paging.pageNumber)}>Save</button>}
                            {isUserAdmin && <button onClick={() => setcurrentid(null)} class="col col-6">Cancel</button>}
                        </li>)
                        : (<li class="table-row">
                            <div class="col col-1" data-label="Name">{data.name}</div>
                            <div class="col col-2" data-label="Price">{data.price}</div>
                            <div class="col col-3" data-label="Quantity">{data.quantity}</div>
                            <div class="col col-4" data-label="Description">{data.description}</div>
                            {isUserAdmin && <button onClick={() => setcurrentid(data.id)} class="col col-5">Edit</button>}
                            {isUserAdmin && <button onClick={(e) => onDell(e,data.id,paging.pageNumber)} class="col col-6">Delete</button>}
                        </li>)
                ))}
            </ul>
            {paging.hasPreviousPage &&
                <button onClick={() => dispatch(getProducts(paging.pageNumber - 1))}>Back</button>
            }
            {paging.hasNextPage &&
                <button onClick={() => dispatch(getProducts(paging.pageNumber + 1))}>Next</button>
            }
            
        </div>
    </div>
    )

}

export default Products